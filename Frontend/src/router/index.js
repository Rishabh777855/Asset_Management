import { createWebHistory } from 'vue-router'
import { createRouter } from 'vue-router'
import AssetListView from '@/views/AssetListView.vue'
import AddAssetView from '@/views/AddAssetView.vue'
import EditAssetView from '@/views/EditAssetView.vue'
import AssetDetailsView from '@/views/AssetDetailsView.vue'
import EmployeeListView from '@/views/EmployeeListView.vue'
import AssignAssetView from '@/views/AssignAssetView.vue'
import EmployeeAssignmentView from '@/views/EmployeeAssignmentView.vue'
import LoginView from '@/views/LoginView.vue'

const routes = [
  {
    path: '/',
    name: 'Login',
    component: LoginView,
  },

  {
    path: '/assets',
    name: 'Assets',
    component: AssetListView,
    meta: {
      requiresAuth: true,
    },
  },

  {
    path: '/assets/add',
    name: 'Add Assets',
    component: AddAssetView,
    meta: {
      requiresAuth: true,
    },
  },

  {
    path: '/assets/edit/:id',
    name: 'Edit Assets',
    component: EditAssetView,
    meta: {
      requiresAuth: true,
    },
  },

  {
    path: '/assets/view/:id',
    name: 'View Asset',
    component: AssetDetailsView,
    meta: {
      requiresAuth: true,
    },
  },

  {
    path: '/employees',
    name: 'Employees',
    component: EmployeeListView,
    meta: {
      requiresAuth: true,
    },
  },

  {
    path: '/employees/:id/assign-asset',
    name: 'AssignAsset',
    component: AssignAssetView,
    meta: {
      requiresAuth: true,
    },
  },

  {
    path: '/employees/:id/assignments',
    name: 'EmployeeAssignment',
    component: EmployeeAssignmentView,
    meta: {
      requiresAuth: true,
    },
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

router.beforeEach((to) => {
  const token = localStorage.getItem('token')

  if (to.meta.requiresAuth && !token) {
    alert("please login first")
    return '/'
  }
})

export default router
