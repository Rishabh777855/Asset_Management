<template>
  <div class="overflow-x-auto bg-white shadow rounded-lg">
    <table class="min-w-full">
      <thead class="bg-gray-100">
        <tr>
          <th class="px-6 py-3 text-left">First Name</th>
          <th class="px-6 py-3 text-left">Last Name</th>
          <th class="px-6 py-3 text-left">Department</th>
          <th class="px-6 py-3 text-left">Designation</th>
          <th class="px-6 py-3 text-center">Actions</th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="employee in props.employees" :key="employee.id" class="border-b hover:bg-gray-50">
          <td class="px-6 py-4">
            {{employee.firstName}}
          </td>

          <td class="px-6 py-4">
            {{ employee.lastName }}
          </td>

          <td class="px-6 py-4">
            {{ employee.department }}
          </td>

          <td class="px-6 py-4">
            {{ employee.designation }}
          </td>

          <td class="px-6 py-4 text-center">
            <button
              @click="$emit('assignAsset', employee.id)"
              class="bg-blue-600 hover:bg-blue-700 text-white px-3 py-1 rounded mr-2"
            >
              Assign Asset
            </button>

            <button
              @click="$emit('view', employee.id)"
              class="bg-green-600 hover:bg-green-700 text-white px-3 py-1 rounded mr-2"
            >
              View
            </button>

            <button
              @click="$emit('edit', employee.id)"
              class="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded mr-2"
            >
              Edit
            </button>

            <button
              @click="$emit('delete', employee.id)"
              class="bg-red-600 hover:bg-red-700 text-white px-3 py-1 rounded"
            >
              Delete
            </button>
          </td>
        </tr>

        <tr v-if="props.employees.length === 0">
          <td colspan="6" class="text-center py-5 text-gray-500">No Employees Found</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
const props = defineProps({
  employees: {
    type: Array,
    required: true,
  },
})

const emit = defineEmits(['view', 'edit', 'delete', 'assignAsset'])
</script>
