<template>
  <div class="max-w-2xl mx-auto bg-white shadow rounded-lg p-6">
    <h2 class="text-2xl font-bold mb-6">Assign Asset</h2>

    <form @submit.prevent="emit('save')">
      <div class="mb-5">
        <label class="block mb-2"> Asset </label>

        <select v-model="props.form.assetId" class="w-full border rounded-lg px-4 py-2">
          <option value="">Select Asset</option>

          <option v-for="asset in props.assets" :key="asset.id" :value="asset.id">
            {{ asset.assetCode }} - {{ asset.name }}
          </option>
        </select>
      </div>

      <div class="mb-5">
        <label class="block mb-2"> Assigned Date </label>

        <input
          type="date"
          v-model="props.form.assignedDate"
          class="w-full border rounded-lg px-4 py-2"
        />
      </div>

      <div class="mb-5">
        <label class="block mb-2"> Remarks </label>

        <textarea
          rows="4"
          v-model="props.form.remarks"
          class="w-full border rounded-lg px-4 py-2"
        />
      </div>

      <button type="submit" class="bg-blue-600 text-white px-5 py-2 rounded-lg">Assign</button>
    </form>
  </div>
</template>

<script setup>
const props = defineProps({
  form: Object,
  assets: Array,
})

const emit = defineEmits(['save'])
</script>
