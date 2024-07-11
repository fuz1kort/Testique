import axios from "axios";

const $host = axios.create({
    baseURL: process.env.REACT_APP_TESTIQUE_API,
    validateStatus: () => true
})

function authInterceptor(config: any) {
    config.withCredentials = true;
    return config
}

$host.interceptors.request.use(authInterceptor)

export {
    $host
}