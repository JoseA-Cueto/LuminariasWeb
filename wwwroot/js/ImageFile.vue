<template>
    <div class="container">
        <div class="col-md-6">
            <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
                <div class="alert alert-primary" role="alert">
                    Imagen cargada con éxito.
                </div>
            </div>

            <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
                <div class="alert alert-danger" role="alert">
                    {{ errorMessage }}
                </div>
            </div>

            <h2 class="text-center mb-4">Subir Nueva Imagen</h2>
            <div v-if="showProgressBar" class="progress">
                <div class="progress-bar progress-bar-striped progress-bar-animated"
                     role="progressbar"
                     aria-valuenow="100"
                     aria-valuemin="0"
                     aria-valuemax="100"
                     style="width: 100%"></div>
            </div>
            <form @submit.prevent="uploadImage" class="needs-validation" novalidate>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label for="imageFile">Imagen</label>
                        <input type="file" ref="imageFile" class="form-control" id="imageFile" accept="image/*" required />
                        <div class="invalid-feedback">
                            Se requiere seleccionar una imagen.
                        </div>
                    </div>
                </div>

                <button type="submit" class="btn btn-dark form-group col-md-12">Subir Imagen</button>
            </form>
        </div>
    </div>
</template>

<script>export default {
  data() {
    return {
      showSuccessAlert: false,
      showErrorAlert: false,
      showProgressBar: false,
      errorMessage: ''
    };
  },
  methods: {
    async uploadImage() {
      try {
        this.showProgressBar = true;

        const formData = new FormData();
        formData.append('file', this.$refs.imageFile.files[0]);

        const response = await fetch('../api/ImageFile/UploadImage', {
          method: 'POST',
          body: formData
        });

        if (response.ok) {
          this.showSuccessAlert = true;
          setTimeout(() => {
            // Redirige a la página de destino deseada después de subir la imagen
            // Por ejemplo: this.$router.push('/admin');
          }, 2000);
        } else {
          const contentType = response.headers.get('content-type');
          if (contentType && contentType.includes('application/json')) {
            const data = await response.json();
            this.showErrorAlert = true;
            this.errorMessage = data.message || 'Error desconocido al subir la imagen.';
            console.error('Error al subir la imagen:', this.errorMessage);
            console.error('Detalles de la respuesta:', data);
          } else {
            this.showErrorAlert = true;
            this.errorMessage = 'Error desconocido al subir la imagen.';
            console.error('Error al subir la imagen:', this.errorMessage);
            console.error('Detalles de la respuesta:', await response.text());
          }
        }
      } catch (error) {
        this.showErrorAlert = true;
        this.errorMessage = 'Error desconocido al subir la imagen.';
        console.error('Error en la petición:', error);
      } finally {
        this.showProgressBar = false;
      }
    }
  }
};</script>
