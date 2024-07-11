import {$host} from "./index";
import RegisterUserDto from "../utils/dto/auth/registerUserDto";
import LoginUserDto from "../utils/dto/auth/loginUserDto";
import ForgotPasswordDto from "../utils/dto/auth/forgotPasswordDto";
import ResetPasswordDto from "../utils/dto/auth/resetPasswordDto";

/** Логин юзера
 * @param dto - LoginUserDto дто для логина юзера*/
export const login = async (dto: LoginUserDto) => {
    const response = await $host.post("api/Auth/Login", dto)
    if (response.status === 200) {
        const cookies = response.headers['set-cookie'];
        if (cookies) {
            cookies.forEach(cookie => {
                document.cookie = cookie;
            });
        }
    } else {
        console.error(response.status, response.statusText);
    }
    
    return response;
}

/** Регистрация юзера
 * @param dto - RegisterUserDto дто для логина юзера*/
export const register = async (dto: RegisterUserDto) => {
    return await $host.post("api/Auth/Register", dto)
}

/** Выход юзера*/
export const forgotPassword = async (dto: ForgotPasswordDto) => {
    return  await $host.post("api/Auth/ForgotPassword", dto);
}

export const resetPassword = async (dto: ResetPasswordDto) => {
    return await $host.put("api/Auth/ResetPassword", dto)
}

/** Выход юзера*/
export const logout = async () => {
    return await $host.delete("api/Auth/Logout")
}

