export default class ResetPasswordDto {
    token: string;
    userId: string;
    newPassword: string;

    constructor(userId: string,
                token: string,
                newPassword: string) {
        this.userId = userId;
        this.token = token;
        this.newPassword = newPassword;
    }
}