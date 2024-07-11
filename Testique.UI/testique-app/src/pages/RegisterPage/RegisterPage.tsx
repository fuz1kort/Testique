import routeNames from "../../utils/routeNames";
import {Link, useNavigate} from "react-router-dom";
import React, {useEffect, useState} from "react";
import './styles/RegisterPage.css'
import RegisterUserDto from "../../utils/dto/auth/registerUserDto";
import {register} from "../../http/authApi";

const RegisterPage = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const navigate = useNavigate()

    const handleRegisterClick = async () => {
        const dto = new RegisterUserDto(username, email, password);
        const response = await register(dto);

        if (response.status === 200) {
            alert("Вы успешно зарегистрировались, вам нужно подтвердить почту");
            navigate(routeNames.HOME_PAGE);
        } else {
            alert(response.statusText)
        }
    };

    return (
        <>
            <div className="account__area">
                <div className="account-bg"></div>
                <div className="container">
                    <div className="account__content">
                        <div className="account__form">
                            <div className="account__title mb-29">
                                <h2>Create Account</h2>
                                <h3>Inter your name, valid email address and password to register your account</h3>
                            </div>
                            <div>
                                <div className="input__group mb-23">
                                    <label>Username</label>
                                    <input type="text" name="f-name" id="f-name" placeholder="Enter your username"
                                           value={username} onChange={(e) => setUsername(e.target.value)}
                                           required/>
                                </div>
                                <div className="input__group mb-23">
                                    <label>Email address</label>
                                    <input type="email" name="email" id="email" placeholder="Enter your email address"
                                           value={email} onChange={(e) => setEmail(e.target.value)}
                                           required/>
                                </div>
                                <div className="input__group mb-23">
                                    <label>Password</label>
                                    <input type="password" name="pass" id="pass" placeholder="Enter your password"
                                           value={password} onChange={(e) => setPassword(e.target.value)}
                                           required minLength={6}
                                    />
                                </div>
                                <div className="item-button">
                                    <div style={{cursor: 'pointer'}} onClick={handleRegisterClick}
                                         className="theme-btn blue">
                                        <span>Register Account</span>
                                        <div className="hover-shape1"></div>
                                        <div className="hover-shape2"></div>
                                        <div className="hover-shape3"></div>
                                    </div>
                                </div>
                            </div>
                            <div className="item-bottom mt-31">
                                <h4>
                                    Already have an account?
                                    <Link to={routeNames.LOGIN_PAGE}> Sign
                                        in now!</Link>
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

export default RegisterPage