using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/filestoragecontainer?view=graph-rest-1.0
    /// </summary>
    public partial class FileStorageContainer
    {
        public enum FileStorageContainerFileStorageContainerStatus
        {
            Inactive ,
            Active ,
        }
        public enum FileStorageContainerPermission
        {
            Reader,
            Writer,
            Manager,
            Owner,
        }

        public Guid? ContainerTypeId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public FileStorageContainerCustomPropertyDictionary? CustomProperties { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public FileStorageContainerFileStorageContainerStatus Status { get; set; }
        public FileStorageContainerViewpoint? Viewpoint { get; set; }
        public Drive? Drive { get; set; }
        public FileStorageContainerPermission Permissions { get; set; }
    }
}
