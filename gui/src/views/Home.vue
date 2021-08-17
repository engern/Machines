<template>
<button @click="showAddMachine = !showAddMachine" class="btn">Add Machine</button>
  <AddMachine v-show="showAddMachine" @add-machine="addMachine" />
  <Machines @delete-machine="deleteMachine" :machines="machines"
  />
</template>

<script>
import Machines from '../components/Machines'
import AddMachine from '../components/AddMachine'
export default {
  name: 'Home',
  components: {
    Machines,
    AddMachine,
  },
  data() {
    return {
      machines: [],
      showAddMachine: false,
    }
  },
  methods: {
    async addMachine(machine) {
      const res = await fetch('api/machine', {
        method: 'POST',
        headers: {
          'Content-type': 'application/json',
        },
        body: JSON.stringify(machine),
      })
      const data = await res.json()
      this.machines = [...this.machines, data]
      this.showAddMachine = false;
    }, 
    async deleteMachine(id) {
      if (confirm('Are you sure you want to delete this machine?')) {
        const res = await fetch(`api/machine/${id}`, {
          method: 'DELETE',
        })
        res.status === 200
          ? (this.machines = this.machines.filter((machine) => machine.id !== id))
          : alert('Error deleting machine')
      }
    },
    async fetchMachines() {
      const res = await fetch('api/machine')
      const data = await res.json()
      return data
    },
    async fetchMachine(id) {
      const res = await fetch(`api/machine/${id}`)
      const data = await res.json()
      return data
    },
  },
  async created() {
    this.machines = await this.fetchMachines()
  },
}
</script>