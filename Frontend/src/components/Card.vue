<template>
  <div class="rounded-xl bg-white p-6 shadow">
    <h2 class="text-xl font-semibold">
      {{ title }}
    </h2>

    <p class="mt-2 text-gray-600">
      {{ description }}
    </p>

    <div class="mt-4">
      <Button @click="$emit('action')">
        Learn More
      </Button>
    </div>
  </div>
</template>

<script setup>
import Button from './Button.vue'

defineProps({
  title: String,
  description: String
})

defineEmits(['action'])
</script>