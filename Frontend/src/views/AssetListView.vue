<template>
  <div class="max-w-7xl mx-auto p-6">
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold">Assets</h1>

      <button
        @click="addAsset"
        class="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 bg-"
      >
        Add Asset
      </button>
    </div>

    <AssetGrid :assets="assets" @edit="editAsset" @delete="deleteAsset" @view="viewAsset" />
  </div>
</template>

<script setup>
import { GetAssets, DeleteAsset } from '@/services/assetService'
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import AssetGrid from '@/components/AssetGrid.vue'

const router = useRouter()

const assets = ref([])

const loadAssets = async () => {
  try {
    const response = await GetAssets()
    assets.value = response.data
  } catch (error) {
    console.log(error)
  }
}

onMounted(() => {
  loadAssets()
})

const addAsset = () => {
  router.push('/assets/add')
}

const editAsset = (id) => {
  router.push(`/assets/edit/${id}`)
}

const viewAsset = (id) => {
  router.push(`/assets/view/${id}`)
}

const deleteAsset = async (id) => {
  if (!confirm('Are sure you want to delete this asset')) {
    return
  }
  try {
    await DeleteAsset(id)

    alert('Asset successfully deleted')

    await loadAssets()
  } catch (error) {
    console.log('Failed to delete asset', error)
  }
}
</script>
