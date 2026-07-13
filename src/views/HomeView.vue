<template>
  <main class="mx-auto max-w-6xl p-6">
    <div class="grid gap-6 md:grid-cols-3">
      <Card
        v-for="card in cards"
        :key="card.id"
        :title="card.title"
        :description="card.description"
        @action="showMessage(card.title)"
      />
    </div>
  </main>
</template>

<script setup>
import Card from '../components/Card.vue'

const cards = [
  {
    id: 1,
    title: 'Vue Components',
    description: 'Reusable building blocks for your UI.'
  },
  {
    id: 2,
    title: 'Tailwind CSS',
    description: 'Utility-first styling framework.'
  },
  {
    id: 3,
    title: 'Vite',
    description: 'Fast development server and bundler.'
  }
]

function showMessage(title) {
  alert(`You clicked ${title}`)
}
</script>