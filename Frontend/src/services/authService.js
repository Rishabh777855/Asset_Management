import api from "./api";

export function Login(loginDto){
    return api.post('Employee/login', loginDto)
}