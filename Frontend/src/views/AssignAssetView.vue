<template>
  <AssetAssignmentForm :form="form" :assets="assets" @save="assignAsset" />
</template>

<script setup>
import AssetAssignmentForm from '@/components/AssetAssignmentForm.vue'
import { GetAvailableAssets } from '@/services/assetService'
import { AssignAsset } from '@/services/assetAssignmentService'
import { ref, reactive, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'

const route = useRoute()
const router = useRouter()

const assets = ref([])

const form = reactive({
  employeeId: route.params.id,
  assetId: '',
  assignedDate: '',
  remarks: '',
})

const loadAssets = async () => {
  const response = await GetAvailableAssets()

  assets.value = response.data
}

const assignAsset = async () => {
  await AssignAsset(form)

  alert('Asset Assigned Successfully')

  router.push('/employees')
}

onMounted(async () => {
  loadAssets()
})
</script>
