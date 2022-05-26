import { createRouter, createWebHistory } from 'vue-router'
import store from '@/store'

const routes = [
  {
    path: '/',
    name: 'HomeView',
    component: import('@/views/Home'),
  },
  {
    path: '/login',
    name: 'LoginView',
    component: import('@/views/User/LoginView'),
  },
  {
    path: '/my-articles',
    name: 'MyArticlesView',
    meta: { authRequired: true },
    component: import('@/views/Article/MyArticlesView'),
  },
  {
    path: '/add-article',
    name: 'AddArticleView',
    meta: { authRequired: true },
    component: import('@/views/Article/AddArticleView'),
  },
  {
    path: '/article/:id',
    name: 'ArticleDetailsView',
    component: import('@/views/Article/ArticleDetailsView'),
  },
  {
    path: '/register',
    name: 'RegisterView',
    component: import('@/views/User/RegisterView'),
  },
  {
    path: '/account',
    name: 'ProfilView',
    meta: { authRequired: true },
    component: import('@/views/User/Authenticated/ProfilView'),
  },
  {
    path: '/security',
    name: 'SecurityView',
    meta: { authRequired: true },
    component: import('@/views/User/Authenticated/SecurityView'),
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

router.beforeEach((to, _, next) => {
  const isAuthenticated = store.getters['users/isAuthenticated']
  const authRequired = to.meta?.authRequired
  if (authRequired) {
    if (isAuthenticated) return next()
    return next({ name: 'LoginView' })
  }

  if (isAuthenticated) {
    if (['LoginView', 'RegisterView'].includes(to.name)) {
      return next({ name: 'HomeView' })
    }
  }
  if (!authRequired) next() // Eğer Gidilmek istenen Sayfa Auth GEREKMİYORSA  o zaman başka bir şeye bakmadan devam et
})

export default router
