<template>
  <div class="p-8">
    <h1 class="text-3xl font-bold">Contact</h1>
    <p>Contact us here.</p>
  </div>

  <div class="p-6">
    <h1 class="text-2xl font-bold mb-4">Counter: {{ count }}</h1>

    <button @click="increment" class="bg-blue-600 text-white px-4 py-2 rounded">Increment</button>
  </div>

  <input v-model="user.username" class="border p-2" />

  <input v-model="user.age" class="border p-2" />

  <p class="">Hello {{ user.username }} you are {{ user.age }} years old</p>
  <p>You are {{ status }}</p>
  <p>{{ message }}</p>
</template>

<script setup>
import router from '@/router'
import { ref, reactive, computed, watch, onMounted } from 'vue'
import { useCounter } from '@/composables/useCounter'

const {count, increment} = useCounter();
const user = reactive({
  username: '',
  age: '',
})

const status = computed(() => {
  if (user.age >= 18) {
    return 'Adult'
  }

  return 'Minor'
})

watch(
  () => user.age,
  (newAge) => {
    console.log('Age changed:', newAge)

    if (newAge % 2 === 0) {
      router.push('/about')
    }
  },
)

const message = ref('Loading...')

onMounted(() => {
  message.value = 'Hello Component has been mounted successfully'
})
</script>
