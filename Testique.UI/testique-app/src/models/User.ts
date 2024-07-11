import {makeAutoObservable} from "mobx";

export default class User {
    _userId: string;
    _email: string;
    _username: string;

    constructor() {
        this._userId = ''
        this._email = ""
        this._username = ""
        makeAutoObservable(this)
    }

    static init(userId: string, email: string, username: string): User {
        let newUser = new User()

        newUser._userId = userId;
        newUser._email = email;
        newUser._username = username;

        return newUser
    }

    get userId() {
        return this._userId;
    }

    get email() {
        return this._email
    }

    get username() {
        return this._username
    }
}