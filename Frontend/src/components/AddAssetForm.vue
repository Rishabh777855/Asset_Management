<template>
  <div class="max-w-4xl mx-auto bg-white shadow-lg rounded-lg p-8 mt-8">
    <h2 class="text-3xl font-bold mb-6 text-gray-800">Create Asset</h2>

    <form @submit.prevent="emit('save')" class="grid grid-cols-1 md:grid-cols-2 gap-6">
      <!-- Asset Code -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Asset Code </label>

        <input
          v-model="props.form.assetCode"
          :disabled="props.isEdit || props.isView"
          type="text"
          placeholder="Enter asset code"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500 input"
        />
      </div>

      <!-- Name -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Name </label>

        <input
          v-model="props.form.name"
          :disabled="props.isView"
          type="text"
          placeholder="Enter asset name"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        />
      </div>

      <!-- Brand -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Brand </label>

        <input
          v-model="props.form.brand"
          :disabled="props.isView"
          type="text"
          placeholder="Enter brand"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        />
      </div>

      <!-- Model -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Model </label>

        <input
          v-model="props.form.model"
          :disabled="props.isView"
          type="text"
          placeholder="Enter model"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        />
      </div>

      <!-- Serial Number -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Serial Number </label>

        <input
          v-model="props.form.serialNumber"
          :disabled="props.isView"
          type="text"
          placeholder="Enter serial number"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        />
      </div>

      <!-- Category -->
      <div v-if="isEdit || isView">
         <label class="block text-lg font-medium text-gray-700 mb-2"> Category </label>
        <input
          :value="form.categoryName"
          disabled
          class="w-full rounded-lg border border-gray-300 bg-gray-100 px-4 py-2 text-gray-600"
        />
      </div>

      <select
        v-else
        v-model="form.assetCategoryId"
        class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none"
      >
        <option value="">Select Category</option>

        <option v-for="category in categories" :key="category.id" :value="category.id">
          {{ category.name }}
        </option>
      </select>

      <!-- Purchase Date -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Purchase Date </label>

        <input
          type="date"
          v-model="props.form.purchaseDate"
          :disabled="props.isEdit || props.isView"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        />
      </div>

      <!-- Purchase Price -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Purchase Price </label>

        <input
          type="number"
          step="0.01"
          v-model="props.form.purchasePrice"
          :disabled="props.isEdit || props.isView"
          placeholder="Enter purchase price"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        />
      </div>

      <!-- Warranty Expiry -->
      <div>
        <label class="block text-lg font-medium text-gray-700 mb-2"> Warranty Expiry Date </label>

        <input
          type="date"
          v-model="props.form.warrantyExpiryDate"
          :disabled="props.isEdit || props.isView"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        />
      </div>

      <!-- Remarks -->
      <div class="md:col-span-2">
        <label class="block text-lg font-medium text-gray-700 mb-2"> Remarks </label>

        <textarea
          v-model="props.form.remarks"
          :disabled="props.isView"
          rows="4"
          placeholder="Enter remarks"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 outline-none input"
        ></textarea>
      </div>

      <!-- Buttons -->
      <div v-if="!props.isView" class="md:col-span-2 flex justify-end gap-4">
        <div v-if="!props.isEdit">
          <button
            type="button"
            @click="emit('reset')"
            class="px-6 py-2 rounded-lg bg-gray-500 text-white hover:bg-gray-600 transition"
          >
            Reset
          </button>
        </div>
        <div>
          <button
            type="submit"
            class="px-6 py-2 rounded-lg bg-blue-600 text-white hover:bg-blue-700 transition"
          >
            Save Asset
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup>
const props = defineProps({
  form: {
    type: Object,
    required: true,
  },
  categories: {
    type: Array,
    required: true,
  },
  isEdit: {
    type: Boolean,
    default: false,
  },
  isView: {
    type: Boolean,
    default: false,
  },
})

const emit = defineEmits(['save', 'reset'])
</script>
