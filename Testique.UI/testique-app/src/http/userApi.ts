import {$host} from "./index";
import User from "../models/User";

export const getUser = async () => {
    const response = await $host.get("api/User/GetUser")
    const data = response!.data
    return response!.status === 200
        ? User.init(data.userId, data.email, data.userName)
        : undefined
}
