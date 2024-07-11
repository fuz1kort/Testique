import routeNames from "../../utils/routeNames";
import React, {useContext, useState} from "react";
import {login} from "../../http/authApi";
import LoginUserDto from "../../utils/dto/auth/loginUserDto";
import loadUser from "../../functions/loadUser";
import {UserContext} from "../../index";
import {Link, useNavigate} from "react-router-dom";
import {observer} from "mobx-react-lite";

const LoginPage = observer(() => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const userStore = useContext(UserContext)
    const navigate = useNavigate()

    const handleSigninClick = () => {
        let dto = new LoginUserDto(username, password);
        login(dto)
            .then(response => {
                    if (response.status === 200 && response.data.isSucceed) {
                        loadUser()
                            .then(user => {
                                if (user !== undefined)
                                    userStore.login(user);
                            })
                            .then(_ => navigate(routeNames.LOGIN_PAGE))

                    } else {
                        alert(response.data.error)
                    }
                }
            )
    }

    return (
        <>
            <div className="account__area">
                <div className="account-bg"></div>
                <div className="container">
                    <div className="account__content">
                        <div className="account__form">
                            <div className="account__title mb-29">
                                <h2>log In</h2>
                                <h3>Enter your email address and password to get access your account</h3>
                            </div>
                            <form action="/" method="post">
                                <div className="input__group mb-23">
                                    <label>Username</label>
                                    <input type="text" name="username" id="username"
                                           onChange={(e) => setUsername(e.target.value)}
                                           placeholder="Enter your username"/>
                                </div>
                                <div className="input__group mb-23">
                                    <label>Password</label>
                                    <input type="password" name="pass" id="pass"
                                           onChange={(e) => setPassword(e.target.value)}
                                           placeholder="Enter your password"/>
                                </div>
                                <div
                                    className="d-flex align-items-center justify-content-between flex-wrap">
                                    <div className="item-text mb-28">
                                        <Link to={routeNames.FORGOT_PASSWORD_PAGE}>Forgot Password?</Link>
                                    </div>
                                </div>
                                <div className="item-button" onClick={handleSigninClick}>
                                    <div className="theme-btn blue" style={{cursor: 'pointer'}}>
                                        <span>Sign in</span>
                                        <div className="hover-shape1"></div>
                                        <div className="hover-shape2"></div>
                                        <div className="hover-shape3"></div>
                                    </div>
                                </div>
                            </form>
                            <div className="item-bottom mt-31">
                                <h4>
                                    Don’t have an account?
                                    <Link to={routeNames.REGISTER_PAGE}> Sign up now!</Link>
                                </h4>
                            </div>
                        </div>
                        <div className="account-shadow"></div>
                    </div>
                </div>
            </div>
        </>
    );
})

export default LoginPage;