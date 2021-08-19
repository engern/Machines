<template>
  <form @submit="onSubmit" class="add-form">
    <div class="form-control">
      <label>Machine name</label>
      <input type="text" v-model="name" name="name" placeholder="Machine name" id="InputMachineName" />
    </div> 

    <input type="submit" value="Save Machine" class="btn btn-block" id="BtnSaveMachine" />
  </form>
</template>

<script>
export default {
  name: 'AddMachine',
  data() {
    return {
      name: '',     
    }
  },
  methods: {
    onSubmit(e) {
      e.preventDefault()
      if (!this.name) {
        alert('Please add a name')
        return
      }
      const newMachine = {
        name: this.name        
      }
      this.$emit('add-machine', newMachine)
      this.name = ''
    },
  },
}
</script>

<style scoped>
.add-form {
  margin-bottom: 40px;
}
.form-control {
  margin: 20px 0;
}
.form-control label {
  display: block;
}
.form-control input {
  width: 100%;
  height: 40px;
  margin: 5px;
  padding: 3px 7px;
  font-size: 17px;
}
.form-control-check {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.form-control-check label {
  flex: 1;
}
.form-control-check input {
  flex: 2;
  height: 20px;
}
</style>