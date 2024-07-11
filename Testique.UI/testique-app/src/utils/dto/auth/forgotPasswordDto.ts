export default class ForgotPasswordDto {
    email: string;

    constructor(password: string) {
        this.email = password;
    }
}