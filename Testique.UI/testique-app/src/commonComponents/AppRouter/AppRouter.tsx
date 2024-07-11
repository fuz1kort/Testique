import {Route, Routes} from "react-router-dom";
import {authRoutes, notAuthRoutes} from "../../utils/routes";
import React, {useContext} from "react";
import {UserContext} from "../../index";
import {observer} from "mobx-react-lite";
import LoginPage from "../../pages/LoginPage/LoginPage";
import NotFoundPage from "../../pages/NotFoundPage/NotFoundPage";

const AppRouter = observer(() => {
    const userStore = useContext(UserContext)

    return (
        <Routes>
            {userStore.isAuth ? (
                <>
                    {authRoutes.map(({path, Component}) => (
                        <Route path={path} element={<Component/>} key={path}/>
                    ))}
                    {notAuthRoutes.map(({path, Component}) => (
                        <Route path={path} element={<Component/>} key={path}/>
                    ))}
                    <Route path="*" element={<NotFoundPage/>}/>
                </>
            ) : (
                <>
                    {notAuthRoutes.map(({path, Component}) => (
                        <Route path={path} element={<Component/>} key={path}/>
                    ))}
                    {authRoutes.map(({path}) => (
                        <Route path={path} element={<LoginPage/>} key={path}/>
                    ))}
                    <Route path="*" element={<NotFoundPage/>}/>
                </>
            )}
            <Route path="*" element={<NotFoundPage/>}/>
        </Routes>
    )
})

export default AppRouter