import { reactive } from "vue"

export function useAssetForm() {
  return reactive({
    assetCode: '',
    name: '',
    brand: '',
    model: '',
    serialNumber: '',
    assetCategoryId: '',
    categoryName: '',
    purchaseDate: '',
    purchasePrice: '',
    warrantyExpiryDate: '',
    remarks: '',
  })
}
