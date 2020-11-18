import Vue from 'vue'
import VueRouter from 'vue-router'
import Autores from '../views/Autores.vue'
import Livros from '../views/Livros.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Autores',
    component: Autores
  },
  {
    path: '/livros',
    name: 'Livros',
    component: Livros
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
