using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class AzureBlobClient
    {
        public BlobServiceClient Client { get; private set; }

        public AzureBlobClient(String accessKey)
        {
            this.Client = new BlobServiceClient(accessKey);
        }
        public AzureBlobClient(Uri uri)
        {
            this.Client = new BlobServiceClient(uri);
        }

        public BlobContainerClient GetBlobContainer(String name)
        {
            return this.Client.GetBlobContainerClient(name);
        }
        public async Task<BlobContainerClient> CreateBlobContainer(String name, PublicAccessType accessType)
        {
            return await this.Client.CreateBlobContainerAsync(name, accessType);
        }
        public String GetBlobContainerSasUrl(BlobContainerClient container, DateTimeOffset expiresOn)
        {
            if (container.CanGenerateSasUri)
            {
                // Create a SAS token that's valid for one hour.
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = container.Name,
                    Resource = "c"
                };
                sasBuilder.ExpiresOn = expiresOn;
                sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);

                Uri u = container.GenerateSasUri(sasBuilder);
                return u.AbsoluteUri;
            }
            else
            {
                throw new InvalidOperationException("You can't create BlobContainerClient.");
            }
        }
        public async Task<List<BlobItem>> GetBlobList(String containerName)
        {
            var container = GetBlobContainer(containerName);
            var l = new List<BlobItem>();
            await foreach (BlobItem item in container.GetBlobsAsync())
            {
                l.Add(item);
            }
            return l;
        }

        public async Task<BlobContentInfo> UploadBlobAsync(String containerName, String blobName, Stream data)
        {
            return await this.UploadBlobAsync(containerName, blobName, data, CancellationToken.None);
        }
        public async Task<BlobContentInfo> UploadBlobAsync(String containerName, String blobName, Stream data, CancellationToken cancellationToken)
        {
            var container = this.GetBlobContainer(containerName);
            var blob = container.GetBlobClient(blobName);
            var info = await blob.UploadAsync(data, cancellationToken);
            return info;
        }
        public async Task<Response> DeleteBlobAsync(String containerName, String blobName
            , DeleteSnapshotsOption deleteSnapshotsOption)
        {
            return await DeleteBlobAsync(containerName, blobName, deleteSnapshotsOption, null, CancellationToken.None);
        }
        public async Task<Response> DeleteBlobAsync(String containerName, String blobName
            , DeleteSnapshotsOption deleteSnapshotsOption, BlobRequestConditions blobRequestConditions, CancellationToken cancellationToken)
        {
            var container = this.GetBlobContainer(containerName);
            var blob = container.GetBlobClient(blobName);
            var res = await blob.DeleteAsync(deleteSnapshotsOption, blobRequestConditions, cancellationToken);
            return res;
        }
        public async Task<Response<Boolean>> DeleteBlobIfExistsAsync(String containerName, String blobName
            , DeleteSnapshotsOption deleteSnapshotsOption, BlobRequestConditions blobRequestConditions, CancellationToken cancellationToken)
        {
            var container = this.GetBlobContainer(containerName);
            var blob = container.GetBlobClient(blobName);
            var res = await blob.DeleteIfExistsAsync(deleteSnapshotsOption, blobRequestConditions, cancellationToken);
            return res;
        }

        public static Boolean IsBlobUrl(Uri uri)
        {
            var u = uri;
            if (u.DnsSafeHost.EndsWith(".blob.core.windows.net")) { return true; }
            return false;
        }
        public BlobClient GetBlobClient(String containerName, String blobName)
        {
            var container = GetBlobContainer(containerName);
            return container.GetBlobClient(blobName);
        }
        public String GetBlobSasUrl(String url, TimeSpan expiresOn)
        {
            return this.GetBlobSasUrl(url, DateTime.Now + expiresOn);
        }
        public String GetBlobSasUrl(String url, DateTimeOffset expiresOn)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out var u))
            {
                if (IsBlobUrl(u))
                {
                    var containerName = u.AbsolutePath.ExtractString('/', '/');
                    if (containerName.IsNullOrEmpty() == false)
                    {
                        var blobNameWithQueryString = u.AbsolutePath.Substring(containerName.Length + 2, u.AbsolutePath.Length - (containerName.Length + 2));
                        var blobName = blobNameWithQueryString.ExtractString(null, '?');
                        var blobClient = this.GetBlobClient(containerName, blobName);
                        return this.GetBlobSasUrl(blobClient, expiresOn);
                    }
                }
            }
            return "";
        }
        public String GetBlobSasUrl(BlobClient blobClient, TimeSpan expiresOn)
        {
            return GetBlobSasUrl(blobClient, DateTime.Now + expiresOn, BlobSasPermissions.Read);
        }
        public String GetBlobSasUrl(BlobClient blobClient, DateTimeOffset expiresOn)
        {
            return GetBlobSasUrl(blobClient, expiresOn, BlobSasPermissions.Read);
        }
        public String GetBlobSasUrl(BlobClient blobClient, DateTimeOffset expiresOn, BlobSasPermissions permissions)
        {
            // Check whether this BlobClient object has been authorized with Shared Key.
            if (blobClient.CanGenerateSasUri)
            {
                // Create a SAS token that's valid for one hour.
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                    BlobName = blobClient.Name,
                    Resource = "b"
                };

                sasBuilder.ExpiresOn = expiresOn;
                sasBuilder.SetPermissions(permissions);

                Uri u = blobClient.GenerateSasUri(sasBuilder);
                return u.AbsoluteUri;
            }
            else
            {
                throw new InvalidOperationException("You can't create BlobContainerClient.");
            }
        }
        public async Task<Int64> GetCloudBlobDirectorySize(String containerName, String prefix)
        {
            Int64 size = 0;
            var container = this.GetBlobContainer(containerName);
            await foreach (BlobItem item in container.GetBlobsAsync(BlobTraits.Metadata))
            {
                if (item.Deleted) { continue; }
                size += item.Properties.ContentLength ?? 0;
            }
            return size;
        }

        public async Task<Response> DownloadBlobToStreamAsync(String containerName, String filePath, Stream stream)
        {
            var container = this.GetBlobContainer(containerName);
            var cl = container.GetBlobClient(filePath);
            return await cl.DownloadToAsync(stream);
        }
    }
}