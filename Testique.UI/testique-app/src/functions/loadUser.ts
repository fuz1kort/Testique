import {getUser} from "../http/userApi";

const loadUser = async () => {
    let user = await getUser()
    return user
}

export default loadUser