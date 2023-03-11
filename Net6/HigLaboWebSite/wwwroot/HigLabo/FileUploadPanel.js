var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { $ } from "./HtmlElementQuery.js";
import { HttpClient } from "./HttpClient.js";
export class FileUploadPanel {
    initialize() {
        $("body").on("change", "[file-upload-panel] input[type='file']", this.fileUploadPanel_Change.bind(this));
        $("body").on("click", "[file-upload-panel] [select-file-panel]", this.selectFilePanel_Click.bind(this));
        $("body").on("click", "[file-upload-panel] [launch-camera-panel]", this.launchCameraPanel_Click.bind(this));
        $("body").on("click", "[file-upload-panel] [take-photo-panel]", this.takePhotoPanel_Click.bind(this));
        $("body").on("input", "[file-upload-panel] [image-size-slider]", this.imageSizeSlider_Change.bind(this));
        this.setImageSliderMaxWidth($(window).getInnerWidth());
    }
    setImageSliderMaxWidth(width) {
        $("body").find("[image-size-slider]").setAttribute("max", width);
    }
    selectFilePanel_Click(target, e) {
        const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
        const f = $(pl).find("input[type='file']").getFirstElement();
        f.click();
    }
    createParameter() {
        return {};
    }
    fileUploadPanel_Change(target, e) {
        const apiPath = $(target).getParentAttribute("api-path");
        const f = target;
        if (f.files.length == 0) {
            return;
        }
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
        HttpClient.postForm(apiPath, formData, this.uploadCallback.bind(this), this.uploadErrorCallback.bind(this), null, target);
        $(f).setValue("");
    }
    uploadCallback(response, target) { }
    uploadErrorCallback(response, target) { }
    launchCameraPanel_Click(target, e) {
        return __awaiter(this, void 0, void 0, function* () {
            const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
            const videoPanel = $(pl).find("[video-panel]").getFirstElement();
            const canvasPanel = $(pl).find("[canvas-panel]").getFirstElement();
            const config = {
                audio: false,
                video: {
                    facingMode: "environment"
                }
            };
            const stream = yield navigator.mediaDevices.getUserMedia(config);
            videoPanel.srcObject = stream;
            videoPanel.onloadedmetadata = (e) => __awaiter(this, void 0, void 0, function* () {
                yield videoPanel.play();
                const w = $(videoPanel).getInnerWidth();
                this.setImageSlider(w);
                this.setPanelSize(pl);
                const stream_settings = stream.getVideoTracks()[0].getSettings();
                canvasPanel.width = stream_settings.width;
                canvasPanel.height = stream_settings.height;
            });
            $(pl).find("[camera-panel]").removeClass("display-none");
        });
    }
    takePhotoPanel_Click(target, e) {
        const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
        const videoPanel = $(pl).find("[video-panel]").getFirstElement();
        const canvasPanel = $(pl).find("[canvas-panel]").getFirstElement();
        videoPanel.pause();
        setTimeout(() => __awaiter(this, void 0, void 0, function* () {
            yield videoPanel.play();
        }), 500);
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
            HttpClient.postForm(apiPath, formData, this.uploadCallback.bind(this), this.uploadErrorCallback.bind(this), null, pl);
        }.bind(this), 'image/jpeg', 0.95);
    }
    imageSizeSlider_Change(target, e) {
        const pl = $(target).getParent("[file-upload-panel]").getFirstElement();
        this.setPanelSize(pl);
    }
    setPanelSize(panel) {
        const pl = panel;
        const videoPanel = $(pl).find("[video-panel]").getFirstElement();
        const canvasPanel = $(pl).find("[canvas-panel]").getFirstElement();
        const w = $(pl).find("[image-size-slider]").getValue();
        $(pl).find("[image-size]").setInnerHtml(w + "px");
        $(videoPanel).setStyle("width", w + "px");
    }
    setImageSlider(width) {
        const pl = $("[file-upload-panel]").getFirstElement();
        if (pl == null) {
            return;
        }
        const w = width;
        $(pl).find("[image-size]").setInnerHtml(w + "px");
        $(pl).find("[image-size-slider]").setValue(w.toString());
    }
}
//# sourceMappingURL=FileUploadPanel.js.map