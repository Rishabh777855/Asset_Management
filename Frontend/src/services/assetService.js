import api from './api'

export function GetAssets() {
  return api.get('/Asset')
}

export function GetAssetsById(id){
  return api.get(`/Asset/${id}`)
}

export function PostAssets(asset) {
  return api.post('/Asset', asset)
}

export function GetAssetsCategory() {
  return api.get('/AssetCategory/categories')
}

export function UpdateAssets(id, asset) {
  return api.put(`Asset/${id}`, asset)
}

export function DeleteAsset(id){
  return api.delete(`Asset/${id}`)
}

export function GetAvailableAssets(){
  return api.get('/Asset/available-assets')
}

export function GetAssetHistory(id){
  return api.get(`/Asset/${id}/history`)
}