<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-100">
    <div class="w-full max-w-md bg-white rounded-xl shadow-lg p-8">
      <h2 class="text-3xl font-bold text-center text-gray-800 mb-8">Login</h2>

      <form @submit.prevent="login">
        <!-- Email -->
        <div class="mb-5">
          <label class="block text-sm font-medium text-gray-700 mb-2"> Email </label>

          <input
            v-model="form.email"
            type="email"
            placeholder="Enter your email"
            class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>

        <!-- Password -->
        <div class="mb-6">
          <label class="block text-sm font-medium text-gray-700 mb-2"> Password </label>

          <input
            v-model="form.password"
            type="password"
            placeholder="Enter your password"
            class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>

        <!-- Login Button -->
        <button
          type="submit"
          class="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition"
        >
          Login
        </button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { Login } from '@/services/authService'
import { reactive } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const form = reactive({
  email: '',
  password: '',
})

const login = async () => {
  try {
    const response = await Login(form)
    localStorage.setItem('token', response.data.token)
    router.push('/assets')
  } catch (error) {
    console.log(error)
    alert('Invalid Id or Password')
  }
}
</script>
