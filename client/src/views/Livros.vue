<template>
  <div class="home">
    <h3>Lista de Livros</h3>
    <div>
      <b-button id="btn-novo" v-b-modal.modal-novo-cadastro  variant="outline-primary">+ Novo</b-button>
      
      <b-table id="table-livros" striped hover :items="livros" :fields="fields"></b-table>
    </div>
    
    <b-modal id="modal-novo-cadastro" title="Novo Livro" hide-footer>

    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
  
      <b-form-group id="input-group-2" label="Nome:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.nome"
          required
          placeholder="Nome do Livro"
        ></b-form-input>
      </b-form-group>  

      <b-form-group id="input-group-3" label="Estoque:" label-for="input-3">
        <b-form-input
          id="input-3"
          v-model="form.estoque"
          required
          placeholder="Quantidade Estoque"
          type="number"
        ></b-form-input>
      </b-form-group>    

      <b-form-group id="input-group-4" label="Autor:" label-for="input-3">
        <b-form-select
          id="input-4"
          v-model="form.autor"
          :options="autores"
          required
        ></b-form-select>
      </b-form-group>        
     
      <div id="btns-forms">
      <b-button type="submit" variant="primary">Cadastrar</b-button>
      <b-button type="reset" variant="danger">Cancelar</b-button>
      </div>
      
    </b-form>


    </b-modal>          
  </div>
</template>

<style lang="scss">
#btn-novo{
  float: right;
  margin-bottom: 10px;
}
#btns-forms{
  float: right;
}
</style>
<script>

import axios from 'axios'
export default {
  name: 'Livros',
  mounted(){
    
    this.getAllData();

  },


  data(){
    return {
        fields: ['id', 'autor.nome', 'nome','estoque'],
        livros: [],
        form: {          
          nome: '',
          estoque: '',
          
        },        
        show: true,
        autores: [],
    }
  },
    methods: {

      onSubmit(evt) {
        evt.preventDefault()
         var livroJson = {
          autor : { id: this.form.autor },
          nome: this.form.nome ,
          estoque: this.form.estoque
        }        

        axios.post('https://localhost:44316/Livro',livroJson).then(() => {                   
          this.$bvModal.hide("modal-novo-cadastro")          
          this.getAllData();       
        })  

      },
      onReset(evt) {
        evt.preventDefault()        
        this.form.estoque = ''
        this.form.nome = ''
        this.form.autor = null
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })   
      } ,
      getAllData(){

          axios.get('https://localhost:44316/Livro').then((response) => {
            this.livros =  response.data
          }) 
          
          axios.get('https://localhost:44316/Autor').then((response) => {
              
              var autoresJson = response.data;
              for(var i=0; i< autoresJson.length; i++) {
                this.autores.push({text: autoresJson[i].nome , value: autoresJson[i].id});
              }      
            
          })          

      }  
  },
};
</script>


