<template>
  <div class="min-h-screen bg-gray-100">
    <AppHeader v-if="!isLoginPage" />
    <RouterView />
  </div>
</template>

<script setup>
import AppHeader from './components/AppHeader.vue'
import { RouterView, useRoute } from 'vue-router'
import { computed } from 'vue'

const route = useRoute()

const isLoginPage = computed(() => route.path === '/')
</script>