<template>
  <AddAssetForm :form="form" :isEdit="true" :isView="false" @save="updateAssets" />
</template>

<script setup>
import { onMounted } from 'vue'
import { UpdateAssets } from '@/services/assetService'
import { useRouter, useRoute } from 'vue-router'
import AddAssetForm from '@/components/AddAssetForm.vue'
import { useAssetForm } from '@/composables/useAssetForm'
import { loadAsset } from '@/composables/useAssets'

const router = useRouter()
const route = useRoute()

const form = useAssetForm()

const updateAssets = async () => {
  try {
    await UpdateAssets(route.params.id, {
      name: form.name,
      brand: form.brand,
      model: form.model,
      serialNumber: form.serialNumber,
      remarks: form.remarks,
    })

    alert('Asset updated successfully')

    router.push('/assets/edit/:id')
  } catch (error) {
    console.log('Failed to update Asset', error)
  }
}

onMounted(async () => {
  await loadAsset(route.params.id, form)
})
</script>
