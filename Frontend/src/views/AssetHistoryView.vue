<template>
  <div class="max-w-7xl mx-auto p-6">
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold">Asset History</h1>

      <button
        @click="router.back()"
        class="bg-gray-600 hover:bg-gray-700 text-white px-4 py-2 rounded-lg"
      >
        Back
      </button>
    </div>

    <div class="overflow-x-auto bg-white shadow rounded-lg">
      <table class="min-w-full divide-y divide-gray-200">
        <thead class="bg-gray-100">
          <tr>
            <th class="px-6 py-3 text-left">Employee</th>
            <th class="px-6 py-3 text-left">Action Date</th>
            <th class="px-6 py-3 text-left">Status</th>
            <th class="px-6 py-3 text-left">Remarks</th>
          </tr>
        </thead>

        <tbody class="divide-y divide-gray-200">
          <tr v-for="history in histories" :key="history.id" class="hover:bg-gray-50">
            <td class="px-6 py-4">
              {{ history.employeeName }}
            </td>

            <td class="px-6 py-4">
              {{ history.actionDate.split('T')[0] }}
            </td>

            <td class="px-6 py-4">
              <span
                class="px-3 py-1 rounded-full text-sm font-medium"
                :class="
                  history.historyType === 'Assigned'
                    ? 'bg-green-100 text-green-700'
                    : 'bg-gray-200 text-gray-700'
                "
              >
                {{ history.historyType }}
              </span>
            </td>

            <td class="px-6 py-4">
              {{ history.remarks || '-' }}
            </td>
          </tr>

          <tr v-if="histories.length === 0">
            <td colspan="5" class="text-center py-6 text-gray-500">No history found.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { useRoute, useRouter } from 'vue-router'
import { ref, onMounted } from 'vue'
import { GetAssetHistory } from '@/services/assetService'

const route = useRoute()
const router = useRouter()

const histories = ref([])

const loadAssetHistory = async () => {
  try {
    const response = await GetAssetHistory(route.params.id)
    histories.value = response.data
  } catch (error) {
    console.error('Error fetching asset history:', error)
  }
}

onMounted(() => {
  loadAssetHistory()
})
</script>
