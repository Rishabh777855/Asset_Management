import { GetAssetsById } from '@/services/assetService'

export async function loadAsset(id, form) {
  const response = await GetAssetsById(id)

  Object.assign(form, response.data)
}
