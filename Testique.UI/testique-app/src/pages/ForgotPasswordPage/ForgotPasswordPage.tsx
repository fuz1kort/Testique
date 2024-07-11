import {Link, useNavigate} from "react-router-dom";
import routeNames from "../../utils/routeNames";
import {useState} from "react";
import {forgotPassword} from "../../http/authApi";
import ForgotPasswordDto from "../../utils/dto/auth/forgotPasswordDto";

const ForgotPasswordPage = () => {
    const [email, setEmail] = useState("");
    const navigate = useNavigate();

    const validateEmail = (email: string) => {
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return regex.test(email);
    };

    const handleGetResetLinkClick = () => {
        if (!validateEmail(email)) {
            alert("Пожалуйста введите почту");
            setEmail("")
            return;
        }

        setEmail("")
        let dto = new ForgotPasswordDto(email)
        forgotPassword(dto)
            .then(response => {
                if (response.status === 200) {
                    alert("Проверьте почту")
                    navigate(routeNames.HOME_PAGE);
                } else {
                    alert(response.statusText)
                }
            })
    }

    return (
        <>
            <div className="account__area">
                <div className="account-bg"></div>
                <div className="container">
                    <div className="account__content">
                        <div className="account__form">
                            <div className="account__title mb-29">
                                <h2>Reset Password</h2>
                                <h3>We’ll send you an email with a link to reset the Password to your account</h3>
                            </div>
                            <div>
                                <div className="input__group mb-40">
                                    <label>Email address</label>
                                    <input type="email" name="email" id="email" value={email}
                                           placeholder="Enter your email address"
                                           onChange={(e) => setEmail(e.target.value)}/>
                                </div>
                                <div className="item-button">
                                    <div style={{cursor: 'pointer'}} onClick={handleGetResetLinkClick}
                                       className="theme-btn blue">
                                        <span>Get Reset Link</span>
                                        <div className="hover-shape1"></div>
                                        <div className="hover-shape2"></div>
                                        <div className="hover-shape3"></div>
                                    </div>
                                </div>
                            </div>
                            <div className="item-bottom mt-40">
                                <h4>
                                    Remember your password?
                                    <Link to={routeNames.LOGIN_PAGE}> Sign in now!</Link>
                                </h4>
                            </div>
                        </div>
                        <div className="account-shadow"></div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default ForgotPasswordPage