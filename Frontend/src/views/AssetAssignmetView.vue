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

      <button
        @click="resetFilters()"
        class="bg-gray-600 hover:bg-gray-700 text-white px-4 py-2 rounded-lg"
      >
        Reset Filters
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
          <tr class="bg-white">
            <th class="px-4 py-2">
              <input
                v-model="filter.employeeName"
                type="text"
                placeholder="Search..."
                class="w-full border rounded px-2 py-1 text-sm"
              />
            </th>

            <th class="px-4 py-2">
              <input
                v-model="filter.assetCode"
                placeholder="Search..."
                class="w-full border rounded px-2 py-1 text-sm"
              />
            </th>

            <th class="px-4 py-2">
              <input
                v-model="filter.assetName"
                placeholder="Search..."
                class="w-full border rounded px-2 py-1 text-sm"
              />
            </th>

            <th class="px-4 py-2">
              <input
                type="date"
                v-model="filter.assignedDate"
                class="w-full border rounded px-2 py-1 text-sm"
              />
            </th>

            <th class="px-4 py-2">
              <select v-model="filter.status" class="w-full border rounded px-2 py-1 text-sm">
                <option value="">All</option>
                <option value="Active">Active</option>
                <option value="Returned">Returned</option>
              </select>
            </th>
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

  <div class="flex items-center justify-between mt-4">
    <span>
      Page {{ pagination.pageNumber }} of {{ pagination.totalPages }} ({{ pagination.totalRecords }}
      Records)
    </span>

    <div class="flex gap-2">
      <button
        @click="previousPage"
        :disabled="!pagination.hasPreviousPage"
        class="px-4 py-2 rounded bg-gray-200 disabled:opacity-50"
      >
        Previous
      </button>

      <button
        @click="nextPage"
        :disabled="!pagination.hasNextPage"
        class="px-4 py-2 rounded bg-gray-200 disabled:opacity-50"
      >
        Next
      </button>
    </div>
  </div>
</template>

<script setup>
import { useRouter } from 'vue-router'
import { ref, reactive, onMounted } from 'vue'
import { GetAllActiveAssignments } from '@/services/assetAssignmentService'
import { watchDebounced } from '@vueuse/core'
import { usePagination } from '@/composables/usePagination'

const { pagination, updatePagination, resetPage } = usePagination()

const router = useRouter()

const assignments = ref([])

const filter = reactive({
  employeeName: '',
  assetCode: '',
  assetName: '',
  assignedDate: '',
  status: '',
})

const loadAssetAssignments = async () => {
  try {
    const response = await GetAllActiveAssignments({
      ...filter,
      pageNumber: pagination.pageNumber,
      pageSize: pagination.pageSize,
    })
    assignments.value = response.data.data

    updatePagination(response.data)
  } catch (error) {
    console.error('Error fetching asset assignments:', error)
  }
}

const previousPage = () => {
  if (!pagination.hasPreviousPage) return

  pagination.pageNumber--
  loadAssetAssignments()
}

const nextPage = () => {
  if (!pagination.hasNextPage) return

  pagination.pageNumber++
  loadAssetAssignments()
}

onMounted(() => {
  loadAssetAssignments()
})

watchDebounced(
  filter,
  () => {
    resetPage()
    loadAssetAssignments()
  },

  {
    debounce: 300,
    deep: true,
  },
)

const resetFilters = () => {
  Object.assign(filter, {
    employeeName: '',
    assetCode: '',
    assetName: '',
    assignedDate: '',
    status: '',
  })

  loadAssetAssignments()
}
</script>
