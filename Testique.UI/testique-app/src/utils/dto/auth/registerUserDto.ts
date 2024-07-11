export default class RegisterUserDto {
    username: string;
    email: string;
    password: string;

    constructor(name: string,
                email: string,
                password: string,) {
        this.username = name;
        this.email = email;
        this.password = password;
    }
}