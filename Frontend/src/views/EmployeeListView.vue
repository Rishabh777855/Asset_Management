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
      @view-assignment="viewAssignment"
    />
  </div>
</template>

<script setup>
import { GetEmployees } from '@/services/employeeService'
import { ref, onMounted } from 'vue'
import EmployeeGrid from '@/components/EmployeeGrid.vue'
import { useRouter } from 'vue-router'

const router = useRouter()

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

const assignAsset = (id) => {
  router.push(`/employees/${id}/assign-asset`)
}

const viewAssignment = (id) => {
  router.push(`/employees/${id}/assignments`);
};

</script>
