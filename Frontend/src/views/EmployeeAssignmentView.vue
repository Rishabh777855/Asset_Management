<template>
  <div class="max-w-7xl mx-auto p-6">
    <h1 class="text-3xl font-bold mb-6">Employee Asset Assignments</h1>

    <div class="overflow-x-auto bg-white shadow rounded-lg">
      <table class="min-w-full divide-y divide-gray-200">
        <thead class="bg-gray-100">
          <tr>
            <th class="px-6 py-3 text-left text-sm font-semibold text-gray-700">Asset Code</th>

            <th class="px-6 py-3 text-left text-sm font-semibold text-gray-700">Asset Name</th>

            <th class="px-6 py-3 text-left text-sm font-semibold text-gray-700">Category</th>

            <th class="px-6 py-3 text-left text-sm font-semibold text-gray-700">Assigned Date</th>

            <th class="px-6 py-3 text-left text-sm font-semibold text-gray-700">Return Date</th>

            <th class="px-6 py-3 text-left text-sm font-semibold text-gray-700">Status</th>

            <th class="px-6 py-3 text-left text-sm font-semibold text-gray-700">Remarks</th>
          </tr>
        </thead>

        <tbody class="divide-y divide-gray-200">
          <tr v-for="assignment in assignments" :key="assignment.id" class="hover:bg-gray-50">
            <td class="px-6 py-4">
              {{ assignment.assetCode }}
            </td>

            <td class="px-6 py-4">
              {{ assignment.assetName }}
            </td>

            <td class="px-6 py-4">
              {{ assignment.categoryName || '-' }}
            </td>

            <td class="px-6 py-4">
              {{ assignment.assignedDate }}
            </td>

            <td class="px-6 py-4">
              {{ assignment.returnDate ?? '-' }}
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

            <td class="px-6 py-4">
              {{ assignment.remarks || '-' }}
            </td>
          </tr>

          <tr v-if="assignments.length === 0">
            <td colspan="7" class="text-center py-6 text-gray-500">No asset assignments found.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { GetEmployeeAssignment } from '@/services/assetAssignmentService'
import { useRoute } from 'vue-router'
import { ref, onMounted } from 'vue'

const route = useRoute()

const assignments = ref([])

const loadAssignments = async () => {
  try {
    const response = await GetEmployeeAssignment(route.params.id)
    assignments.value = response.data
  } catch (error) {
    console.log('Error loading Employee Assignments', error)
  }
}

onMounted(() => {
  loadAssignments()
})
</script>
