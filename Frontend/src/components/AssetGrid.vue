<template>
  <div class="overflow-x-auto bg-white shadow rounded-lg">
    <table class="min-w-full">
      <thead class="bg-gray-100">
        <tr>
          <th class="px-6 py-3 text-left">Asset Code</th>
          <th class="px-6 py-3 text-left">Name</th>
          <th class="px-6 py-3 text-left">Brand</th>
          <th class="px-6 py-3 text-left">Model</th>
          <th class="px-6 py-3 text-left">Category</th>
          <th class="px-6 py-3 text-left">Purchase Price</th>
          <th class="px-6 py-3 text-center">Actions</th>
        </tr>

        <tr class="bg-white">
          <th class="px-4 py-2">
            <input
              v-model="props.filter.assetCode"
              type="text"
              placeholder="Search..."
              class="w-full border rounded px-2 py-1 text-sm"
            />
          </th>

          <th class="px-4 py-2">
            <input
              v-model="props.filter.assetName"
              type="text"
              placeholder="Search..."
              class="w-full border rounded px-2 py-1 text-sm"
            />
          </th>

          <th class="px-4 py-2">
            <input
              v-model="props.filter.brand"
              type="text"
              placeholder="Search..."
              class="w-full border rounded px-2 py-1 text-sm"
            />
          </th>

          <th class="px-4 py-2">
            <input
              v-model="props.filter.model"
              type="text"
              placeholder="Search..."
              class="w-full border rounded px-2 py-1 text-sm"
            />
          </th>

          <th class="px-4 py-2">
            <input
              v-model="props.filter.categoryName"
              type="text"
              placeholder="Search..."
              class="w-full border rounded px-2 py-1 text-sm"
            />
          </th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="asset in props.assets" :key="asset.id" class="border-b hover:bg-gray-50">
          <td class="px-6 py-4">
            {{ asset.assetCode }}
          </td>

          <td class="px-6 py-4">
            {{ asset.name }}
          </td>

          <td class="px-6 py-4">
            {{ asset.brand }}
          </td>

          <td class="px-6 py-4">
            {{ asset.model }}
          </td>

          <td class="px-6 py-4">
            {{ asset.categoryName }}
          </td>

          <td class="px-6 py-4">₹ {{ asset.purchasePrice }}</td>

          <td class="px-6 py-4">
            <div class="flex items-center justify-center gap-2 whitespace-nowrap">
              <button
                @click="$emit('view', asset.id)"
                class="bg-green-600 hover:bg-green-700 text-white px-3 py-1 rounded"
              >
                View
              </button>

              <button
                @click="$emit('edit', asset.id)"
                class="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded"
              >
                Edit
              </button>

              <button
                @click="$emit('delete', asset.id)"
                class="bg-red-600 hover:bg-red-700 text-white px-3 py-1 rounded"
              >
                Delete
              </button>

              <button
                @click="$emit('history', asset.id)"
                class="bg-blue-600 hover:bg-blue-700 text-white px-3 py-1 rounded"
              >
                History
              </button>
            </div>
          </td>
        </tr>

        <tr v-if="props.assets.length === 0">
          <td colspan="6" class="text-center py-5 text-gray-500">No Assets Found</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
const props = defineProps({
  assets: {
    type: Array,
    required: true,
  },
  filter: {
    type: Object,
    required: true,
  },
})

const emit = defineEmits(['view', 'edit', 'delete', 'history'])
</script>
