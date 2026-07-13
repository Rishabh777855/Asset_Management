import api from "./api";

export function GetEmployees(){
    return api.get("/Employee")
}