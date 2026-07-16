import api from "./api";

export function AssignAsset(asset) {
    return api.post('/AssetAssignment/assign', asset)
}

export function GetEmployeeAssignment(id){
    return api.get(`/AssetAssignment/employee/${id}`)
}

export function GetAllActiveAssignments(){
    return api.get('/AssetAssignment/activeAssignments')
}