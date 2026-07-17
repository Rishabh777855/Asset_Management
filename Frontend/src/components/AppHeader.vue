<template>
  <header class="bg-blue-600 text-white shadow">
    <div class="mx-auto max-w-6xl px-6 py-4">
      <h1 class="text-2xl font-bold">Asset Management System</h1>
      <nav class="flex gap-6">
        <RouterLink to="/assets">Assets</RouterLink>
        <RouterLink to="/employees">Employees</RouterLink>
      </nav>
    </div>
  </header>
</template>

<script setup>
import { RouterLink } from 'vue-router'
</script>
