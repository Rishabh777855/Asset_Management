<template>
  <AddAssetForm :form="form" :isEdit="false" :isView="true" />
</template>

<script setup>
import { onMounted } from 'vue'
import AddAssetForm from '@/components/AddAssetForm.vue'
import { useRoute } from 'vue-router'
import { useAssetForm } from '@/composables/useAssetForm'
import { loadAsset } from '@/composables/useAssets'

const route = useRoute()

const form = useAssetForm()

onMounted(async () => {
  await loadAsset(route.params.id, form)
})
</script>
