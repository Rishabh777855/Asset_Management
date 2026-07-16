import axios from 'axios'

const api = axios.create({
  baseURL: 'http://localhost:5253/api',
})

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token')

  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }

  return config
})

api.interceptors.response.use(
  (response) => response,

  async (error) => {
    const originalRequest = error.config

    if (error.response?.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true

      try {
        const refreshToken = localStorage.getItem('refreshToken')

        const response = await axios.post('http://localhost:5253/api/Employee/refresh', {
          refreshToken,
        })

        localStorage.setItem('token', response.data.token)

        localStorage.setItem('refreshToken', response.data.refreshToken)

        originalRequest.headers.Authorization = `Bearer ${response.data.accessToken}`

        return api(originalRequest)
      } catch (refreshError) {
        localStorage.removeItem('token')
        localStorage.removeItem('refreshToken')

        alert('Session expired. Please login again.')

        window.location.href = '/'

        return Promise.reject(refreshError)
      }
    }

    return Promise.reject(error)
  },
)

export default api
