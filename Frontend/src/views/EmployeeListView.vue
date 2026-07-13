<template>
  <div class="max-w-7xl mx-auto p-6">
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold">Employees</h1>
    </div>
    <EmployeeGrid
      :employees="employees"
      @edit="editEmployee"
      @delete="deleteEmployee"
      @view="viewEmployee"
      @assign-asset="assignAsset"
    />
  </div>
</template>

<script setup>
import { GetEmployees } from '@/services/employeeService'
import { ref, onMounted } from 'vue'
import EmployeeGrid from '@/components/EmployeeGrid.vue'

const employees = ref([])

const loadEmployees = async () => {
  try {
    const response = await GetEmployees()
    employees.value = response.data
  } catch (error) {
    console.log(error)
  }
}

onMounted(() => {
  loadEmployees()
})

const assignAsset = () => {
  router.push('/assets/assign')
}

</script>
