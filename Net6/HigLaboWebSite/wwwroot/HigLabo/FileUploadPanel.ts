import { $ } from "./HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "./HttpClient.js";

export class FileUploadPanel {
    public initialize() {
        $("body").on("change", "[file-upload-panel] input[type='file']", this.fileUploadPanel_Change.bind(this));
        $("body").on("click", "[file-upload-panel] [select-file-panel]", this.selectFilePanel_Click.bind(this));
        $("body").on("click", "[file-upload-panel] [launch-camera-panel]", this.launchCameraPanel_Click.bind(this));
        $("body").on("click", "[file-upload-panel] [take-photo-panel]", this.takePhotoPanel_Click.bind(this));
        $("body").on("input", "[file-upload-panel] [image-size-slider]", this.imageSizeSlider_Change.bind(this));

        this.setImageSliderMaxWidth($(window).getInnerWidth());
    }
    public setImageSliderMaxWidth(width) {
        $("body").find("[image-size-slider]").setAttribute("max", width);
    }

    private selectFilePanel_Click(target: Element, e: Event) {
        const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
        const f = $(pl).find("input[type='file']").getFirstElement() as HTMLInputElement;
        f.click();
    }
    public createParameter() {
        return {};
    }
    private fileUploadPanel_Change(target: Element, e: Event) {
        const apiPath = $(target).getParentAttribute("api-path");
        const f = target as HTMLInputElement;
        if (f.files.length == 0) { return; }

        const formData = new FormData();
        for (var i = 0; i < f.files.length; i++) {
            formData.append(f.name, f.files[i]);
        }

        const p = this.createParameter();
        const pNameList = Object.getOwnPropertyNames(p);
        for (var i = 0; i < pNameList.length; i++) {
            let v = p[pNameList[i]];
            formData.append(pNameList[i], v);
        }
        HttpClient.postForm(apiPath, formData, this.uploadCallback.bind(this), this.uploadErrorCallback.bind(this)
            , null, target);

        $(f).setValue("");
    }
    public uploadCallback(response: HttpResponse, target: Element) { }
    public uploadErrorCallback(response: HttpResponse, target: Element) { }

    private async launchCameraPanel_Click(target: Element, e: Event) {
        const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
        const videoPanel = $(pl).find("[video-panel]").getFirstElement() as HTMLVideoElement;
        const canvasPanel = $(pl).find("[canvas-panel]").getFirstElement() as HTMLCanvasElement;

        const config = {
            audio: false,
            video: {
                facingMode: "environment"
            }
        };

        const stream = await navigator.mediaDevices.getUserMedia(config);

        videoPanel.srcObject = stream;
        videoPanel.onloadedmetadata = async (e) => {
            await videoPanel.play();
            //画面に表示するのはスクリーンのサイズに合わせて縮小
            const w = $(videoPanel).getInnerWidth();
            this.setImageSlider(w);
            this.setPanelSize(pl);
            //写真データは元の解像度で取得
            const stream_settings = stream.getVideoTracks()[0].getSettings();
            canvasPanel.width = stream_settings.width;
            canvasPanel.height = stream_settings.height;
        };

        $(pl).find("[camera-panel]").removeClass("display-none");
    }
    private takePhotoPanel_Click(target: Element, e: Event) {
        const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
        const videoPanel = $(pl).find("[video-panel]").getFirstElement() as HTMLVideoElement;
        const canvasPanel = $(pl).find("[canvas-panel]").getFirstElement() as HTMLCanvasElement;

        videoPanel.pause();
        setTimeout(async () => {
            await videoPanel.play();
        }, 500);

        const ctx = canvasPanel.getContext("2d");
        ctx.drawImage(videoPanel, 0, 0, canvasPanel.width, canvasPanel.height);

        canvasPanel.toBlob(function (blob) {
            var formData = new FormData();
            formData.append("file", blob, "camerafile.jpg");

            const p = this.createParameter();
            const pNameList = Object.getOwnPropertyNames(p);
            for (var i = 0; i < pNameList.length; i++) {
                let v = p[pNameList[i]];
                formData.append(pNameList[i], v);
            }

            const apiPath = $(pl).getParentAttribute("api-path");
            HttpClient.postForm(apiPath, formData, this.uploadCallback.bind(this), this.uploadErrorCallback.bind(this)
                , null, pl);
        }.bind(this), 'image/jpeg', 0.95);
    }
    private imageSizeSlider_Change(target: Element, e: Event) {
        const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
        this.setPanelSize(pl);
    }
    private setPanelSize(panel) {
        const pl = panel;
        const videoPanel = $(pl).find("[video-panel]").getFirstElement() as HTMLVideoElement;
        const canvasPanel = $(pl).find("[canvas-panel]").getFirstElement() as HTMLCanvasElement;

        const w = $(pl).find("[image-size-slider]").getValue();
        $(pl).find("[image-size]").setInnerHtml(w + "px");
        $(videoPanel).setStyle("width", w + "px");
    }
    private setImageSlider(width: number) {
        const pl = $("[file-upload-panel]").getFirstElement();
        if (pl == null) { return; }

        const w = width;
        $(pl).find("[image-size]").setInnerHtml(w + "px");
        $(pl).find("[image-size-slider]").setValue(w.toString());
    }
}
