import { reactive } from 'vue'

export function usePagination(pageSize = 10) {
  const pagination = reactive({
    pageNumber: 1,
    pageSize: 1,
    totalRecords: 0,
    totalPages: 0,
    hasPreviousPage: false,
    hasNextPage: false,
  })

  const updatePagination = (response) => {
    pagination.pageNumber = response.pageNumber
    pagination.pageSize = response.pageSize
    pagination.totalRecords = response.totalRecords
    pagination.totalPages = response.totalPages
    pagination.hasPreviousPage = response.hasPreviousPage
    pagination.hasNextPage = response.hasNextPage
  }

  const resetPage = () => {
    pagination.pageNumber = 1
  }

  return {
    pagination,
    updatePagination,
    resetPage,
  }
}
