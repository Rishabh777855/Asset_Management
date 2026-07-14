import { createWebHistory } from 'vue-router'
import AboutView from '@/views/AboutView.vue'
import ContactView from '@/views/ContactView.vue'
import HomeView from '@/views/HomeView.vue'
import { createRouter } from 'vue-router'
import AssetListView from '@/views/AssetListView.vue'
import AddAssetView from '@/views/AddAssetView.vue'
import EditAssetView from '@/views/EditAssetView.vue'
import AssetDetailsView from '@/views/AssetDetailsView.vue'
import EmployeeListView from '@/views/EmployeeListView.vue'
import AssignAssetView from '@/views/AssignAssetView.vue'
import EmployeeAssignmentView from '@/views/EmployeeAssignmentView.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView,
  },
  {
    path: '/about',
    name: 'About',
    component: AboutView,
  },
  {
    path: '/contact',
    name: 'Contact',
    component: ContactView,
  },

  {
    path: '/assets',
    name: 'Assets',
    component: AssetListView,
  },

  {
    path: '/assets/add',
    name: 'Add Assets',
    component: AddAssetView,
  },

  {
    path: '/assets/edit/:id',
    name: 'Edit Assets',
    component: EditAssetView,
  },

  {
    path: '/assets/view/:id',
    name: 'View Asset',
    component: AssetDetailsView,
  },

  {
    path: '/employees',
    name: 'Employees',
    component: EmployeeListView,
  },

  {
    path: '/employees/:id/assign-asset',
    name: 'AssignAsset',
    component: AssignAssetView,
  },

  {
    path: '/employees/:id/assignments',
    name: 'AssignAsset',
    component: EmployeeAssignmentView,
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
