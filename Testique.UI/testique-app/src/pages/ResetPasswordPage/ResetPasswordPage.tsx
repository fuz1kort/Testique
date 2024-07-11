import {useLocation, useNavigate} from "react-router-dom";
import React, {useState} from "react";
import ResetPasswordDto from "../../utils/dto/auth/resetPasswordDto";
import {resetPassword} from "../../http/authApi";
import routeNames from "../../utils/routeNames";

const ResetPasswordPage = () => {
    const [password, setpassword] = useState('');
    const navigate = useNavigate();
    const location = useLocation();

    const queryParams = new URLSearchParams(location.search);
    const userId = queryParams.get('userId')!;
    const token = queryParams.get('token')!;

    const handleResetPasswordClick = () => {
        let dto = new ResetPasswordDto(userId, token, password)
        resetPassword(dto)
            .then(response => {
                if (response.status === 200) {
                    console.log(response)
                    const resetState = {
                        isSucceed: response.data.isSucceed,
                        error: response.data.error
                    };
                    navigate(routeNames.PASSWORD_HAS_BEEN_RESET_PAGE, { state: resetState });
                } else {
                    alert(response.statusText)
                }
            })
    }
    
    return (
        <div className="account__area">
            <div className="account-bg"></div>
            <div className="container">
                <div className="account__content">
                    <div className="account__form">
                        <div className="account__title mb-29">
                            <h2>Reset password</h2>
                        </div>
                        <div>
                            <div className="input__group mb-23">
                                <label>New password</label>
                                <input type="password" name="firstPassword" id="firstPassword"
                                       value={password}
                                       onChange={(e) => setpassword(e.target.value)}
                                       placeholder="Enter new password"
                                       minLength={6}
                                       required/>
                                {password.length > 0 && password.length < 6 && (
                                    <p style={{color: 'red', marginTop: '20px'}}>Password must be at least 6 characters
                                        long</p>
                                )}
                            </div>
                            <div className="item-text mb-28"/>
                            <div className="item-button" onClick={handleResetPasswordClick}>
                                <div className="theme-btn blue" style={{cursor: 'pointer'}}>
                                    <span>Reset password</span>
                                    <div className="hover-shape1"></div>
                                    <div className="hover-shape2"></div>
                                    <div className="hover-shape3"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="account-shadow"></div>
                </div>
            </div>
        </div>
    )
}

export default ResetPasswordPage