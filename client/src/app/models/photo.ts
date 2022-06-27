export class Photo {
    title: string;
    description: string;
    photoBase64: string;
    userId: string;
    constructor(title: string, description: string, photoBase64: string, userId: string) {
        this.title = title;
        this.description = description;
        this.photoBase64 = photoBase64;
        this.userId = userId;
    }
}
