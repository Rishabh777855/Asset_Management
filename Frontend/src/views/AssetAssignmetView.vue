<template>
  <div class="max-w-7xl mx-auto p-6">
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold">Asset Assignments</h1>

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
            <th class="px-6 py-3 text-left">Asset Code</th>
            <th class="px-6 py-3 text-left">Asset Name</th>
            <th class="px-6 py-3 text-left">Assigned Date</th>
            <th class="px-6 py-3 text-left">Status</th>
          </tr>
        </thead>

        <tbody class="divide-y divide-gray-200">
          <tr v-for="assignment in assignments" :key="assignment.id" class="hover:bg-gray-50">
            <td class="px-6 py-4">
              {{ assignment.employeeName }}
            </td>

            <td class="px-6 py-4">
              {{ assignment.assetCode }}
            </td>

            <td class="px-6 py-4">
              {{ assignment.assetName }}
            </td>

            <td class="px-6 py-4">
              {{ assignment.assignedDate.split('T')[0] }}
            </td>

            <td class="px-6 py-4">
              <span
                class="px-3 py-1 rounded-full text-sm font-medium"
                :class="
                  assignment.status === 'Active'
                    ? 'bg-green-100 text-green-700'
                    : 'bg-gray-200 text-gray-700'
                "
              >
                {{ assignment.status }}
              </span>
            </td>
          </tr>

          <tr v-if="assignments.length === 0">
            <td colspan="5" class="text-center py-6 text-gray-500">No Assignment found.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { useRouter } from 'vue-router'
import { ref, onMounted } from 'vue'
import { GetAllActiveAssignments } from '@/services/assetAssignmentService'

const router = useRouter()

const assignments = ref([])

const loadAssetAssignments = async () => {
  try {
    const response = await GetAllActiveAssignments()
    assignments.value = response.data
  } catch (error) {
    console.error('Error fetching asset assignments:', error)
  }
}

onMounted(() => {
  loadAssetAssignments()
})
</script>
