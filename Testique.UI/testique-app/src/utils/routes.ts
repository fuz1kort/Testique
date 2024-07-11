import routeNames from "./routeNames";
import HomePage from "../pages/HomePage/HomePage";
import LoginPage from "../pages/LoginPage/LoginPage";
import ForgotPasswordPage from "../pages/ForgotPasswordPage/ForgotPasswordPage";
import EmailConfirmedPage from "../pages/EmailConfirmedPage/EmailConfirmedPage";
import ResetPasswordPage from "../pages/ResetPasswordPage/ResetPasswordPage";
import RegisterPage from "../pages/RegisterPage/RegisterPage";
import PasswordHasBeenResetPage from "../pages/PasswordHasBeenResetPage/PasswordHasBeenResetPage";

export const notAuthRoutes = [
    {
        path: routeNames.LOGIN_PAGE,
        Component: LoginPage
    },
    {
        path: routeNames.REGISTER_PAGE,
        Component: RegisterPage
    },
    {
        path: routeNames.FORGOT_PASSWORD_PAGE,
        Component: ForgotPasswordPage
    },
    {
        path: routeNames.RESET_PASSWORD_PAGE,
        Component: ResetPasswordPage
    },
    {
        path: routeNames.PASSWORD_HAS_BEEN_RESET_PAGE,
        Component: PasswordHasBeenResetPage
    },
    {
        path: routeNames.EMAIL_CONFIRMED_PAGE,
        Component: EmailConfirmedPage
    }
]

export const authRoutes = [
    {
        path: routeNames.HOME_PAGE,
        Component: HomePage
    }
]