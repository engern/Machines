<template>
  <div class="machine">
    <h3>
      <input v-if="editMode" v-model="newMachineName">
      <span v-if="!editMode">{{ machineName }}</span>
      <i v-if="!editMode" @click="$emit('delete-machine', machine.id)" class="fas fa-times"></i>
      <i v-if="!editMode" @click="editMode = true; newMachineName = machineName;" class="fas fa-pen"></i>
      <i v-if="editMode" @click="editMode = false" class="fas fa-window-close"></i>
      <i v-if="editMode" @click="saveMachine()" class="fas fa-save"></i>

    </h3>
  </div>
</template>

<script>
export default {
  name: 'Machine',
  props: {
    machine: Object,
  },
  data() {
    return {
      editMode: false,
      machineName : '',    
      newMachineName :'' 
    }
  },
  methods: {
    async saveMachine() {
    
      var updatedMachine = {
         id: this.machine.id,
         name: this.newMachineName
        };
      const res = await fetch('api/machine', {
        method: 'PUT',
        headers: {
          'Content-type': 'application/json',
        },
        body: JSON.stringify(updatedMachine),
      })
      if(res.status === 200)
        this.machineName = this.newMachineName;
      else
        alert('Error updating machine')
      
      this.editMode = false;

     },
  },
  mounted: function(){
    this.machineName = this.machine.name;
  }
}
</script>

<style scope>
.fa-times {
  color: red;
}
.fas{
  cursor: pointer;
}
.machine {
  background: #f4f4f4;
  margin: 5px;
  padding: 10px 20px;
}

.machine h3 i {
  float:right;
  margin-left: 20px;
}
</style>