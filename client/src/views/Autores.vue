<template>
  <div class="home">
    <h3>Lista de Autores</h3>
    <div>
      <b-button id="btn-novo" v-b-modal.modal-novo-cadastro  variant="outline-primary">+ Novo</b-button>       
      <b-table id="table-autores" striped hover :items="autores" responsive="sm" >
      </b-table>
    </div>
    
    <b-modal id="modal-novo-cadastro" title="Novo Livro" hide-footer>

    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
  
      <b-form-group id="input-group-1" label="Nome:" label-for="input-1">
        <b-form-input
          id="input-1"
          v-model="form.nome"
          required
          placeholder="Nome do Autor"
        ></b-form-input>
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
  name: 'Autores',
  mounted(){
    
    this.getAllData();

  },


  data(){
    return {   
        fields: ['id','nome','acao'],     
        autores: [],
        form: {          
          nome: '',          
          
        },        
        show: true,        
    }
  },
    methods: {

      onSubmit(evt) {
        evt.preventDefault()
         var autorJson = {          
          nome: this.form.nome ,          
        }        

        axios.post('https://localhost:44316/Autor',autorJson).then(() => {                   
          this.$bvModal.hide("modal-novo-cadastro")          
          this.getAllData();       
        })  

      },
      onReset(evt) {
        evt.preventDefault()                
        this.form.nome = ''        
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })   
      } ,
      getAllData(){

          axios.get('https://localhost:44316/Autor').then((response) => {
            this.autores =  response.data
          }) 
                  

      },
      info(item, index) {
        this.infoModal.title = `Row index: ${index}`
        this.infoModal.content = JSON.stringify(item, null, 2)        
      }        
  },
};
</script>


