<template>
  <AddAssetForm
    :form="form"
    :categories="categories"
    :isEdit="false"
    :isView="false"
    @save="saveAsset"
    @reset="resetForm"
  />
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { PostAssets, GetAssetsCategory } from '@/services/assetService'
import { useRouter } from 'vue-router'
import AddAssetForm from '@/components/AddAssetForm.vue'
import { useAssetForm } from '@/composables/useAssetForm'

const router = useRouter()

const categories = ref([])

const form = useAssetForm()

const loadCategories = async () => {
  try {
    const response = await GetAssetsCategory()
    categories.value = response.data
  } catch (error) {
    console.error(error)
  }
}

const saveAsset = async () => {
  try {
    await PostAssets(form)

    alert('Asset Added Successfully')

    router.push('/assets/add')
  } catch (error) {
    console.log(error)
    alert('Failed to create asset')
  }
}

onMounted(() => {
  loadCategories()
})

const resetForm = () => {
  form.assetCode = ''
  form.name = ''
  form.brand = ''
  form.model = ''
  form.serialNumber = ''
  form.assetCategoryId = ''
  form.purchaseDate = ''
  form.purchasePrice = ''
  form.warrantyExpiryDate = ''
  form.remarks = ''
}
</script>
